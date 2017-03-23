namespace MARRSS.Forms
{
    partial class ObjectiveBuilderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectiveBuilderForm));
            this.availableObjectivesListBox = new System.Windows.Forms.ListBox();
            this.addObjectiveButton = new System.Windows.Forms.Button();
            this.removeObjectiveButton = new System.Windows.Forms.Button();
            this.selectedObjectiveListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ObjectivesPresetSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // availableObjectivesListBox
            // 
            this.availableObjectivesListBox.FormattingEnabled = true;
            this.availableObjectivesListBox.Items.AddRange(new object[] {
            "Priority",
            "Satellite Fairness",
            "Station Fairness",
            "Scheduled Duration",
            "Scheduled Contacts"});
            this.availableObjectivesListBox.Location = new System.Drawing.Point(12, 39);
            this.availableObjectivesListBox.Name = "availableObjectivesListBox";
            this.availableObjectivesListBox.Size = new System.Drawing.Size(186, 186);
            this.availableObjectivesListBox.TabIndex = 0;
            // 
            // addObjectiveButton
            // 
            this.addObjectiveButton.Location = new System.Drawing.Point(239, 71);
            this.addObjectiveButton.Name = "addObjectiveButton";
            this.addObjectiveButton.Size = new System.Drawing.Size(75, 23);
            this.addObjectiveButton.TabIndex = 1;
            this.addObjectiveButton.Text = " -->";
            this.addObjectiveButton.UseVisualStyleBackColor = true;
            this.addObjectiveButton.Click += new System.EventHandler(this.addObjectiveButton_Click);
            // 
            // removeObjectiveButton
            // 
            this.removeObjectiveButton.Location = new System.Drawing.Point(239, 121);
            this.removeObjectiveButton.Name = "removeObjectiveButton";
            this.removeObjectiveButton.Size = new System.Drawing.Size(75, 23);
            this.removeObjectiveButton.TabIndex = 2;
            this.removeObjectiveButton.Text = "<--";
            this.removeObjectiveButton.UseVisualStyleBackColor = true;
            this.removeObjectiveButton.Click += new System.EventHandler(this.removeObjectiveButton_Click);
            // 
            // selectedObjectiveListBox
            // 
            this.selectedObjectiveListBox.FormattingEnabled = true;
            this.selectedObjectiveListBox.Items.AddRange(new object[] {
            "0X - Priority",
            "0X - Satellite Fairness",
            "0X - Station Fairness",
            "0X - Scheduled Duration",
            "0X - Scheduled Contacts"});
            this.selectedObjectiveListBox.Location = new System.Drawing.Point(357, 39);
            this.selectedObjectiveListBox.Name = "selectedObjectiveListBox";
            this.selectedObjectiveListBox.Size = new System.Drawing.Size(186, 186);
            this.selectedObjectiveListBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(357, 231);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ObjectivesPresetSelection
            // 
            this.ObjectivesPresetSelection.FormattingEnabled = true;
            this.ObjectivesPresetSelection.Location = new System.Drawing.Point(357, 10);
            this.ObjectivesPresetSelection.Name = "ObjectivesPresetSelection";
            this.ObjectivesPresetSelection.Size = new System.Drawing.Size(186, 21);
            this.ObjectivesPresetSelection.TabIndex = 6;
            this.ObjectivesPresetSelection.SelectedIndexChanged += new System.EventHandler(this.ObjectivesPresetSelection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            // 
            // ObjectiveBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 264);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ObjectivesPresetSelection);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectedObjectiveListBox);
            this.Controls.Add(this.removeObjectiveButton);
            this.Controls.Add(this.addObjectiveButton);
            this.Controls.Add(this.availableObjectivesListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ObjectiveBuilderForm";
            this.Text = "Objective Function";
            this.Load += new System.EventHandler(this.ObjectiveBuilderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox availableObjectivesListBox;
        private System.Windows.Forms.Button addObjectiveButton;
        private System.Windows.Forms.Button removeObjectiveButton;
        private System.Windows.Forms.ListBox selectedObjectiveListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox ObjectivesPresetSelection;
        private System.Windows.Forms.Label label1;
    }
}