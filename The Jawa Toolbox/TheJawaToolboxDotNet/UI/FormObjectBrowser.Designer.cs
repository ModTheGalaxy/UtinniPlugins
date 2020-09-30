﻿namespace TJT.UI
{
    partial class FormObjectBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvDirectories = new System.Windows.Forms.TreeView();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblCreateSnapshotNodesAtPlayer = new System.Windows.Forms.Label();
            this.nudSnapshotNodeCount = new System.Windows.Forms.NumericUpDown();
            this.btnCreateSnapshotNodesAtPlayer = new UtinniCoreDotNet.UI.Controls.UtinniButton();
            this.cmsObjectFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCreateSnapshotNodeAtPlayer = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapshotNodeCount)).BeginInit();
            this.cmsObjectFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvDirectories
            // 
            this.tvDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvDirectories.HideSelection = false;
            this.tvDirectories.Location = new System.Drawing.Point(12, 12);
            this.tvDirectories.Name = "tvDirectories";
            this.tvDirectories.Size = new System.Drawing.Size(216, 421);
            this.tvDirectories.TabIndex = 0;
            this.tvDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectories_AfterSelect);
            // 
            // lbFiles
            // 
            this.lbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.IntegralHeight = false;
            this.lbFiles.Location = new System.Drawing.Point(234, 12);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(554, 392);
            this.lbFiles.TabIndex = 1;
            this.lbFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbFiles_MouseDown);
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(11, 442);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 2;
            this.lblFilter.Text = "Filter";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(46, 439);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(742, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblCreateSnapshotNodesAtPlayer
            // 
            this.lblCreateSnapshotNodesAtPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateSnapshotNodesAtPlayer.AutoSize = true;
            this.lblCreateSnapshotNodesAtPlayer.Location = new System.Drawing.Point(485, 415);
            this.lblCreateSnapshotNodesAtPlayer.Name = "lblCreateSnapshotNodesAtPlayer";
            this.lblCreateSnapshotNodesAtPlayer.Size = new System.Drawing.Size(167, 13);
            this.lblCreateSnapshotNodesAtPlayer.TabIndex = 42;
            this.lblCreateSnapshotNodesAtPlayer.Text = "Create Snapshot node(s) at player";
            // 
            // nudSnapshotNodeCount
            // 
            this.nudSnapshotNodeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSnapshotNodeCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudSnapshotNodeCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudSnapshotNodeCount.Enabled = false;
            this.nudSnapshotNodeCount.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nudSnapshotNodeCount.Location = new System.Drawing.Point(660, 413);
            this.nudSnapshotNodeCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSnapshotNodeCount.Name = "nudSnapshotNodeCount";
            this.nudSnapshotNodeCount.Size = new System.Drawing.Size(40, 20);
            this.nudSnapshotNodeCount.TabIndex = 340;
            this.nudSnapshotNodeCount.TabStop = false;
            this.nudSnapshotNodeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSnapshotNodeCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCreateSnapshotNodesAtPlayer
            // 
            this.btnCreateSnapshotNodesAtPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateSnapshotNodesAtPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCreateSnapshotNodesAtPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateSnapshotNodesAtPlayer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreateSnapshotNodesAtPlayer.Location = new System.Drawing.Point(706, 410);
            this.btnCreateSnapshotNodesAtPlayer.Name = "btnCreateSnapshotNodesAtPlayer";
            this.btnCreateSnapshotNodesAtPlayer.Size = new System.Drawing.Size(82, 23);
            this.btnCreateSnapshotNodesAtPlayer.TabIndex = 41;
            this.btnCreateSnapshotNodesAtPlayer.Text = "Create";
            this.btnCreateSnapshotNodesAtPlayer.UseVisualStyleBackColor = false;
            this.btnCreateSnapshotNodesAtPlayer.Click += new System.EventHandler(this.btnCreateSnapshotNodesAtPlayer_Click);
            // 
            // cmsObjectFile
            // 
            this.cmsObjectFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateSnapshotNodeAtPlayer});
            this.cmsObjectFile.Name = "cmsObjectFile";
            this.cmsObjectFile.Size = new System.Drawing.Size(239, 26);
            // 
            // tsmiCreateSnapshotNodeAtPlayer
            // 
            this.tsmiCreateSnapshotNodeAtPlayer.Name = "tsmiCreateSnapshotNodeAtPlayer";
            this.tsmiCreateSnapshotNodeAtPlayer.Size = new System.Drawing.Size(238, 22);
            this.tsmiCreateSnapshotNodeAtPlayer.Text = "Create Snapshot node at player";
            this.tsmiCreateSnapshotNodeAtPlayer.Click += new System.EventHandler(this.tsmiCreateSnapshotNodeAtPlayer_Click);
            // 
            // FormObjectBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.nudSnapshotNodeCount);
            this.Controls.Add(this.lblCreateSnapshotNodesAtPlayer);
            this.Controls.Add(this.btnCreateSnapshotNodesAtPlayer);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.tvDirectories);
            this.Name = "FormObjectBrowser";
            this.Text = "Object Browser";
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapshotNodeCount)).EndInit();
            this.cmsObjectFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDirectories;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private UtinniCoreDotNet.UI.Controls.UtinniButton btnCreateSnapshotNodesAtPlayer;
        private System.Windows.Forms.Label lblCreateSnapshotNodesAtPlayer;
        internal System.Windows.Forms.NumericUpDown nudSnapshotNodeCount;
        private System.Windows.Forms.ContextMenuStrip cmsObjectFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateSnapshotNodeAtPlayer;
    }
}