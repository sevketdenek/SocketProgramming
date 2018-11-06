namespace ClientForm
{
    partial class Form1
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
            this.tName = new System.Windows.Forms.TextBox();
            this.bConnect = new System.Windows.Forms.Button();
            this.rTBoxChat = new System.Windows.Forms.RichTextBox();
            this.rTBoxSendMessage = new System.Windows.Forms.RichTextBox();
            this.bSendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(2, 3);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(268, 20);
            this.tName.TabIndex = 0;
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(276, 1);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(77, 23);
            this.bConnect.TabIndex = 1;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // rTBoxChat
            // 
            this.rTBoxChat.Location = new System.Drawing.Point(2, 41);
            this.rTBoxChat.Name = "rTBoxChat";
            this.rTBoxChat.Size = new System.Drawing.Size(351, 106);
            this.rTBoxChat.TabIndex = 2;
            this.rTBoxChat.Text = "";
            // 
            // rTBoxSendMessage
            // 
            this.rTBoxSendMessage.Location = new System.Drawing.Point(2, 204);
            this.rTBoxSendMessage.Name = "rTBoxSendMessage";
            this.rTBoxSendMessage.Size = new System.Drawing.Size(351, 106);
            this.rTBoxSendMessage.TabIndex = 3;
            this.rTBoxSendMessage.Text = "";
            // 
            // bSendMessage
            // 
            this.bSendMessage.Location = new System.Drawing.Point(2, 316);
            this.bSendMessage.Name = "bSendMessage";
            this.bSendMessage.Size = new System.Drawing.Size(351, 23);
            this.bSendMessage.TabIndex = 4;
            this.bSendMessage.Text = "Send";
            this.bSendMessage.UseVisualStyleBackColor = true;
            this.bSendMessage.Click += new System.EventHandler(this.bSendMessage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 351);
            this.Controls.Add(this.bSendMessage);
            this.Controls.Add(this.rTBoxSendMessage);
            this.Controls.Add(this.rTBoxChat);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.tName);
            this.Name = "Form1";
            this.Text = "Client Chat ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.RichTextBox rTBoxChat;
        private System.Windows.Forms.RichTextBox rTBoxSendMessage;
        private System.Windows.Forms.Button bSendMessage;
    }
}

