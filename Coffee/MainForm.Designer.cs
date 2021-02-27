using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Vanara.PInvoke.User32;

namespace Coffee
{
    partial class MainForm
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

        private async Task CoffeeMachine()
        {
            int x = 1;
            
            try
            {
                var input = new INPUT();
                input.type = INPUTTYPE.INPUT_MOUSE;
                input.mi.dwFlags = 0x01;
                var size = Marshal.SizeOf(input);

                while (true)
                {
                    x = (x == 1) ? -1 : 1;
                    
                    for (int i = 0; i < 100; ++i)
                    {
                        input.mi.dx = x;
                        input.mi.dy = x;
                        if (this.isActive)
                        {
                            var _ = SendInput(1, new INPUT[] { input }, size);
                        }

                        await Task.Delay(TimeSpan.FromSeconds(15));
                    }
                }
            }
            catch
            {}
        }

        private void InitCoffeeMachine()
        {
            this.isActive = true;
            _ = CoffeeMachine();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.coffeeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // coffeeIcon
            // 
            this.coffeeIcon.ContextMenuStrip = this.contextMenu;
            this.coffeeIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("coffeeIcon.Icon")));
            this.coffeeIcon.Text = "Coffee";
            this.coffeeIcon.Visible = true;
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activateToolStripMenuItem,
            this.toolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(271, 120);
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.activateToolStripMenuItem.Text = "Deactivate";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(267, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 354);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "MainForm";
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public string GetCurrentLabel()
        {
            return this.isActive ? "Deactivate" : "Activate";
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem item)
            {
                isActive = !isActive;
                item.Text = GetCurrentLabel();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_VisibleChanged(object sender, System.EventArgs e)
        {
            this.Visible = false;
        }

        #endregion

        private NotifyIcon coffeeIcon;
        private volatile bool isActive;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem activateToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}

