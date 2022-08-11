namespace FormUI
{
    partial class DashBoard
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.peopleFoundListbox = new System.Windows.Forms.ListBox();
            this.LastNameText = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.firstNameInsLabel = new System.Windows.Forms.Label();
            this.firstNameInsText = new System.Windows.Forms.TextBox();
            this.lastNameInsLabel = new System.Windows.Forms.Label();
            this.lastNameInsText = new System.Windows.Forms.TextBox();
            this.emailAdressInsLabel = new System.Windows.Forms.Label();
            this.emailAdressInsText = new System.Windows.Forms.TextBox();
            this.phoneNumberInsLabel = new System.Windows.Forms.Label();
            this.numberPhoneInsText = new System.Windows.Forms.TextBox();
            this.insertRecordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // peopleFoundListbox
            // 
            this.peopleFoundListbox.FormattingEnabled = true;
            this.peopleFoundListbox.ItemHeight = 31;
            this.peopleFoundListbox.Location = new System.Drawing.Point(38, 12);
            this.peopleFoundListbox.Name = "peopleFoundListbox";
            this.peopleFoundListbox.Size = new System.Drawing.Size(352, 128);
            this.peopleFoundListbox.TabIndex = 0;
            // 
            // LastNameText
            // 
            this.LastNameText.Location = new System.Drawing.Point(242, 160);
            this.LastNameText.Name = "LastNameText";
            this.LastNameText.Size = new System.Drawing.Size(224, 38);
            this.LastNameText.TabIndex = 1;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(32, 160);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(151, 32);
            this.LastNameLabel.TabIndex = 2;
            this.LastNameLabel.Text = "Last Name";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(242, 214);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(148, 65);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // firstNameInsLabel
            // 
            this.firstNameInsLabel.AutoSize = true;
            this.firstNameInsLabel.Location = new System.Drawing.Point(32, 332);
            this.firstNameInsLabel.Name = "firstNameInsLabel";
            this.firstNameInsLabel.Size = new System.Drawing.Size(152, 32);
            this.firstNameInsLabel.TabIndex = 5;
            this.firstNameInsLabel.Text = "First Name";
            // 
            // firstNameInsText
            // 
            this.firstNameInsText.Location = new System.Drawing.Point(242, 329);
            this.firstNameInsText.Name = "firstNameInsText";
            this.firstNameInsText.Size = new System.Drawing.Size(224, 38);
            this.firstNameInsText.TabIndex = 4;
            // 
            // lastNameInsLabel
            // 
            this.lastNameInsLabel.AutoSize = true;
            this.lastNameInsLabel.Location = new System.Drawing.Point(32, 387);
            this.lastNameInsLabel.Name = "lastNameInsLabel";
            this.lastNameInsLabel.Size = new System.Drawing.Size(151, 32);
            this.lastNameInsLabel.TabIndex = 7;
            this.lastNameInsLabel.Text = "Last Name";
            // 
            // lastNameInsText
            // 
            this.lastNameInsText.Location = new System.Drawing.Point(242, 384);
            this.lastNameInsText.Name = "lastNameInsText";
            this.lastNameInsText.Size = new System.Drawing.Size(224, 38);
            this.lastNameInsText.TabIndex = 6;
            // 
            // emailAdressInsLabel
            // 
            this.emailAdressInsLabel.AutoSize = true;
            this.emailAdressInsLabel.Location = new System.Drawing.Point(32, 441);
            this.emailAdressInsLabel.Name = "emailAdressInsLabel";
            this.emailAdressInsLabel.Size = new System.Drawing.Size(182, 32);
            this.emailAdressInsLabel.TabIndex = 9;
            this.emailAdressInsLabel.Text = "Email Adress";
            // 
            // emailAdressInsText
            // 
            this.emailAdressInsText.Location = new System.Drawing.Point(242, 438);
            this.emailAdressInsText.Name = "emailAdressInsText";
            this.emailAdressInsText.Size = new System.Drawing.Size(224, 38);
            this.emailAdressInsText.TabIndex = 8;
            // 
            // phoneNumberInsLabel
            // 
            this.phoneNumberInsLabel.AutoSize = true;
            this.phoneNumberInsLabel.Location = new System.Drawing.Point(32, 494);
            this.phoneNumberInsLabel.Name = "phoneNumberInsLabel";
            this.phoneNumberInsLabel.Size = new System.Drawing.Size(205, 32);
            this.phoneNumberInsLabel.TabIndex = 11;
            this.phoneNumberInsLabel.Text = "Phone Number";
            // 
            // numberPhoneInsText
            // 
            this.numberPhoneInsText.Location = new System.Drawing.Point(242, 491);
            this.numberPhoneInsText.Name = "numberPhoneInsText";
            this.numberPhoneInsText.Size = new System.Drawing.Size(224, 38);
            this.numberPhoneInsText.TabIndex = 10;
            // 
            // insertRecordButton
            // 
            this.insertRecordButton.Location = new System.Drawing.Point(242, 544);
            this.insertRecordButton.Name = "insertRecordButton";
            this.insertRecordButton.Size = new System.Drawing.Size(148, 65);
            this.insertRecordButton.TabIndex = 13;
            this.insertRecordButton.Text = "Insert";
            this.insertRecordButton.UseVisualStyleBackColor = true;
            this.insertRecordButton.Click += new System.EventHandler(this.InsertRecordButton_Click);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 642);
            this.Controls.Add(this.insertRecordButton);
            this.Controls.Add(this.phoneNumberInsLabel);
            this.Controls.Add(this.numberPhoneInsText);
            this.Controls.Add(this.emailAdressInsLabel);
            this.Controls.Add(this.emailAdressInsText);
            this.Controls.Add(this.lastNameInsLabel);
            this.Controls.Add(this.lastNameInsText);
            this.Controls.Add(this.firstNameInsLabel);
            this.Controls.Add(this.firstNameInsText);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.LastNameText);
            this.Controls.Add(this.peopleFoundListbox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DashBoard";
            this.Text = "SQL Data Access Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox peopleFoundListbox;
        private System.Windows.Forms.TextBox LastNameText;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label firstNameInsLabel;
        private System.Windows.Forms.TextBox firstNameInsText;
        private System.Windows.Forms.Label lastNameInsLabel;
        private System.Windows.Forms.TextBox lastNameInsText;
        private System.Windows.Forms.Label emailAdressInsLabel;
        private System.Windows.Forms.TextBox emailAdressInsText;
        private System.Windows.Forms.Label phoneNumberInsLabel;
        private System.Windows.Forms.TextBox numberPhoneInsText;
        private System.Windows.Forms.Button insertRecordButton;
    }
}

