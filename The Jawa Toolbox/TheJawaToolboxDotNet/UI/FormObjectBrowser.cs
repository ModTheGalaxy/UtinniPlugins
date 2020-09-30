﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtinniCore.Swg.Math;
using UtinniCore.Utinni;
using UtinniCore.Utinni.CuiHud;
using UtinniCoreDotNet.Callbacks;
using UtinniCoreDotNet.Commands;
using UtinniCoreDotNet.PluginFramework;
using UtinniCoreDotNet.UI;
using UtinniCoreDotNet.UI.Forms;
using Appearance = UtinniCore.Utinni.Appearance;

namespace TJT.UI
{
    public partial class FormObjectBrowser : Form, IEditorForm
    {
        private readonly IEditorPlugin editorPlugin;

        private readonly Dictionary<string, List<string>> objectRepo = new Dictionary<string, List<string>>();

        private UtinniCore.Utinni.Object dragDropObject;


        public FormObjectBrowser(IEditorPlugin editorPlugin)
        {
            InitializeComponent();

            this.editorPlugin = editorPlugin;

            Task loadRepo = LoadRepo();

            GameDragDropEventHandlers.OnDragDrop += OnDragDrop;
            GameDragDropEventHandlers.OnDragEnter += OnDragEnter;
            GameDragDropEventHandlers.OnDragOver += OnDragOver;
        }

        private async Task LoadRepo()
        {
            while (!Game.IsRunning)
            {
                await Task.Delay(1);
            }

            var dirInfo = Game.Repository.GetDirectoryInfo("object");

            for (int i = 0; i < dirInfo.Size; i++)
            {
                string fn = Game.Repository.GetFilenameAt(dirInfo.StartIndex + i);

                if (fn.EndsWith(".iff"))
                {
                    int posStart = fn.IndexOf('/');
                    int posEnd = fn.LastIndexOf('/');

                    if (posStart == posEnd)
                    {
                        // Skip root files as they're not proper Object files
                        continue;   
                    }

                    string dir = fn.Substring(posStart + 1, posEnd - posStart);
                    List<string> filenames;
                    if (objectRepo.TryGetValue(dir, out filenames))
                    {
                        filenames.Add(fn);
                    }
                    else
                    {
                        filenames = new List<string> { fn };
                        objectRepo.Add(dir, filenames);
                    }
                }
            }

            TreeNode tmpRootNode = new TreeNode();
            foreach (KeyValuePair<string, List<string>> dir in objectRepo)
            {
                // Split and loop through the directory's subdirectories and created nested nodes
                TreeNode curNode = tmpRootNode;
                string dirPath = dir.Key;
                string[] splitPaths;
                while ((splitPaths = dirPath.Split('/')).Length > 1)
                {
                    if (!curNode.Nodes.ContainsKey(splitPaths[0]))
                    {
                        curNode.Nodes.Add(splitPaths[0], splitPaths[0]);
                    }
                    curNode = curNode.Nodes[curNode.Nodes.IndexOfKey(splitPaths[0])];
                    dirPath = dirPath.Substring(splitPaths[0].Length + 1);
                }
            }

            tvDirectories.SuspendLayout();
            TreeNode[] tmpNodes = new TreeNode[tmpRootNode.Nodes.Count];
            tmpRootNode.Nodes.CopyTo(tmpNodes, 0);
            tvDirectories.Nodes.AddRange(tmpNodes);
            tvDirectories.ResumeLayout();
        }

        public string GetName()
        {
            return this.Text;
        }

        public void Create(IEditorPlugin editorPlugin)
        {
            // Check if the form is already open
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormObjectBrowser))
                {
                    form.Activate();
                    return;
                }
            }

            // If not, create a new one
            FormObjectBrowser formLog = new FormObjectBrowser(editorPlugin);
            formLog.Show();
        }

        private List<string> currentFilenames;
        private TreeNode previousNode;
        private void tvDirectories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvDirectories.SelectedNode != null && tvDirectories.SelectedNode != previousNode)
            {
                string dirPath = tvDirectories.SelectedNode.Text + '/';

                // Loop backwards through the TreeView nodes to assemble the full path
                TreeNode curNode = tvDirectories.SelectedNode;
                while (curNode.Parent != null)
                {
                    curNode = curNode.Parent;
                    dirPath = curNode.Text + "/" + dirPath;
                }

                lbFiles.BeginUpdate();
                lbFiles.Items.Clear();
                if (objectRepo.TryGetValue(dirPath, out List<string> filenames))
                {
                    currentFilenames = filenames;
                    lbFiles.Items.AddRange(currentFilenames.ToArray());
                    previousNode = tvDirectories.SelectedNode;
                }
                lbFiles.EndUpdate();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            lbFiles.BeginUpdate();
            lbFiles.Items.Clear();

            if (txtFilter.Text == "")
            {
                lbFiles.Items.AddRange(currentFilenames.ToArray());
            }
            else
            {
                foreach (string filename in currentFilenames)
                {
                    if (filename.Contains(txtFilter.Text))
                    {
                        lbFiles.Items.Add(filename);
                    }
                }
            }
            lbFiles.EndUpdate();
        }

        private void lbFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && lbFiles.SelectedItem != null)
            {
                lbFiles.DoDragDrop(lbFiles.SelectedItem, DragDropEffects.Copy);
            }
        }

        private void CreateDragDropObject(string filename)
        {
            var player = Game.Player;
            var camera = GroundScene.Get().CurrentCamera;

            if (player == null || camera == null)
            {
                return;
            }

            var newTransform = new Transform(player.ObjectToParent)
            {
                Position = cui_hud.GetCursorWorldPosition()
            };

            var objTemplate = ObjectTemplateList.GetObjectTemplateByFilename(filename);
            if (objTemplate == null)
            {
                return;
            }

            if (objTemplate.PortalLayoutFilename == "")
            {
                dragDropObject = ObjectTemplate.CreateObject(filename);
            }
            else
            {
                dragDropObject = UtinniCore.Utinni.Object.Ctor;
                dragDropObject.AddNotification(0x019136E4, false); // ToDo Label the magic number

                var pob = PortalPropertyTemplateList.GetPobByCrcString(PersistentCrcString.Ctor(objTemplate.PortalLayoutFilename));
                dragDropObject.SetAppearance(Appearance.Create(pob.ExteriorAppearanceName));
                UtinniCore.Utinni.RenderWorld.render_world.AddObjectNotifications(dragDropObject); // ToDo see if the dupe call is needed (Copied from TJT)
            }

            dragDropObject.ClientObject.SetParentCell(camera.ParentCell);

            CellProperty.SetPortalTransitions(false);
            dragDropObject.TransformO2w = newTransform;
            CellProperty.SetPortalTransitions(true);

            UtinniCore.Utinni.RenderWorld.render_world.AddObjectNotifications(dragDropObject);
            dragDropObject.ClientObject.EndBaselines();
            dragDropObject.AddToWorld();
        }

        private void UpdateDragDropObjectPosition(Vector position)
        {
            if (dragDropObject == null)
            {
                return;
            }

            Transform newTransform;

            var camera = GroundScene.Get().CurrentCamera;
            if (camera.ParentObject == null)
            {
                newTransform = new Transform(Game.Player.ObjectToParent)
                {
                    Position = position
                };
            }
            else
            {
                Transform o2c = new Transform();
                Transform w2c = new Transform();
                Transform c2w = camera.ParentObject.TransformO2w;

                w2c.Invert(c2w);
                o2c.Multiply(w2c, dragDropObject.Transform);

                newTransform = o2c;
            }

            dragDropObject.TransformO2w = newTransform;
        }

        private void ConvertDragDropObjectToWorldSnapshotNode()
        {
            GroundSceneCallbacks.AddUpdateLoopCall(() =>
            {
                WorldSnapshotReaderWriter.Node node = WorldSnapshot.CreateAddNode(dragDropObject.TemplateFilename, dragDropObject.Transform);

                if (node != null)
                {
                    editorPlugin.AddUndoCommand(this, new AddUndoCommandEventArgs(new AddWorldSnapshotNodeCommand(node)));
                }

                // Cleanup the temporary DragDrop object
                dragDropObject.Remove();
                dragDropObject = null;
            });
        }

        private void OnDragDrop(object sender, DragEventArgs e)
        {
            ConvertDragDropObjectToWorldSnapshotNode();
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text)) // ToDo custom format 
            {
                this.Focus();
                this.BringToFront();
                e.Effect = DragDropEffects.Copy;
                if (dragDropObject == null)
                {
                    string dragData = (string)e.Data.GetData(DataFormats.Text); // ToDo custom format 

                    GroundSceneCallbacks.AddUpdateLoopCall(() =>
                    {
                        CreateDragDropObject(dragData);
                    });
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            if (dragDropObject == null)
            {
                return;
            }

            Panel pnl = (Panel)sender;
            var point = pnl.PointToClient(Cursor.Position);
            GroundSceneCallbacks.AddUpdateLoopCall(() =>
            {
                var pos = cui_hud.CollideCursorWithWorld(point.X, point.Y);
                UpdateDragDropObjectPosition(pos);
            });
        }

    }
}

