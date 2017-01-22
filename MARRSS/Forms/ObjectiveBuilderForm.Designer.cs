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
            this.button2 = new System.Windows.Forms.Button();
            this.ObjectivesPresetSelection = new System.Windows.Forms.ComboBox();
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
            this.availableObjectivesListBox.Location = new System.Drawing.Point(12, 65);
            this.availableObjectivesListBox.Name = "availableObjectivesListBox";
            this.availableObjectivesListBox.Size = new System.Drawing.Size(186, 186);
            this.availableObjectivesListBox.TabIndex = 0;
            // 
            // addObjectiveButton
            // 
            this.addObjectiveButton.Location = new System.Drawing.Point(239, 97);
            this.addObjectiveButton.Name = "addObjectiveButton";
            this.addObjectiveButton.Size = new System.Drawing.Size(75, 23);
            this.addObjectiveButton.TabIndex = 1;
            this.addObjectiveButton.Text = " -->";
            this.addObjectiveButton.UseVisualStyleBackColor = true;
            this.addObjectiveButton.Click += new System.EventHandler(this.addObjectiveButton_Click);
            // 
            // removeObjectiveButton
            // 
            this.removeObjectiveButton.Location = new System.Drawing.Point(239, 147);
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
            this.selectedObjectiveListBox.Location = new System.Drawing.Point(357, 65);
            this.selectedObjectiveListBox.Name = "selectedObjectiveListBox";
            this.selectedObjectiveListBox.Size = new System.Drawing.Size(186, 186);
            this.selectedObjectiveListBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 264);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ObjectivesPresetSelection
            // 
            this.ObjectivesPresetSelection.FormattingEnabled = true;
            this.ObjectivesPresetSelection.Items.AddRange(new object[] {
            "New Preset",
            "Priority only",
            "Fairness only"});
            this.ObjectivesPresetSelection.Location = new System.Drawing.Point(357, 36);
            this.ObjectivesPresetSelection.Name = "ObjectivesPresetSelection";
            this.ObjectivesPresetSelection.Size = new System.Drawing.Size(186, 21);
            this.ObjectivesPresetSelection.TabIndex = 6;
            this.ObjectivesPresetSelection.SelectedIndexChanged += new System.EventHandler(this.ObjectivesPresetSelection_SelectedIndexChanged);
            // 
            // ObjectiveBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 299);
            this.Controls.Add(this.ObjectivesPresetSelection);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectedObjectiveListBox);
            this.Controls.Add(this.removeObjectiveButton);
            this.Controls.Add(this.addObjectiveButton);
            this.Controls.Add(this.availableObjectivesListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ObjectiveBuilderForm";
            this.Text = "Objective Function";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox availableObjectivesListBox;
        private System.Windows.Forms.Button addObjectiveButton;
        private System.Windows.Forms.Button removeObjectiveButton;
        private System.Windows.Forms.ListBox selectedObjectiveListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox ObjectivesPresetSelection;
    }
}