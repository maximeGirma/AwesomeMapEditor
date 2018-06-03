namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.generateNewMap = new System.Windows.Forms.Button();
            this.entryPoint = new System.Windows.Forms.Button();
            this.exitPoint = new System.Windows.Forms.Button();
            this.obstacle = new System.Windows.Forms.Button();
            this.empyPlace = new System.Windows.Forms.Button();
            this.mapReset = new System.Windows.Forms.Button();
            this.saveMap = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.deleteMap = new System.Windows.Forms.Button();
            this.loadMaps = new System.Windows.Forms.Button();
            this.generateJsFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generateNewMap
            // 
            this.generateNewMap.Location = new System.Drawing.Point(735, 12);
            this.generateNewMap.Name = "generateNewMap";
            this.generateNewMap.Size = new System.Drawing.Size(107, 23);
            this.generateNewMap.TabIndex = 0;
            this.generateNewMap.Text = "generate new map";
            this.generateNewMap.UseVisualStyleBackColor = true;
            this.generateNewMap.Click += new System.EventHandler(this.generateNewMap_Click);
            // 
            // entryPoint
            // 
            this.entryPoint.Location = new System.Drawing.Point(735, 57);
            this.entryPoint.Name = "entryPoint";
            this.entryPoint.Size = new System.Drawing.Size(75, 23);
            this.entryPoint.TabIndex = 1;
            this.entryPoint.Text = "entry";
            this.entryPoint.UseVisualStyleBackColor = true;
            this.entryPoint.Click += new System.EventHandler(this.entryPoint_Click);
            // 
            // exitPoint
            // 
            this.exitPoint.Location = new System.Drawing.Point(735, 112);
            this.exitPoint.Name = "exitPoint";
            this.exitPoint.Size = new System.Drawing.Size(75, 23);
            this.exitPoint.TabIndex = 2;
            this.exitPoint.Text = "exit";
            this.exitPoint.UseVisualStyleBackColor = true;
            this.exitPoint.Click += new System.EventHandler(this.exitPoint_Click);
            // 
            // obstacle
            // 
            this.obstacle.Location = new System.Drawing.Point(735, 167);
            this.obstacle.Name = "obstacle";
            this.obstacle.Size = new System.Drawing.Size(75, 23);
            this.obstacle.TabIndex = 3;
            this.obstacle.Text = "obstacle";
            this.obstacle.UseVisualStyleBackColor = true;
            this.obstacle.Click += new System.EventHandler(this.obstacle_Click);
            // 
            // empyPlace
            // 
            this.empyPlace.Location = new System.Drawing.Point(735, 222);
            this.empyPlace.Name = "empyPlace";
            this.empyPlace.Size = new System.Drawing.Size(90, 23);
            this.empyPlace.TabIndex = 4;
            this.empyPlace.Text = "empty";
            this.empyPlace.UseVisualStyleBackColor = true;
            this.empyPlace.Click += new System.EventHandler(this.emptyPlace_Click);
            // 
            // mapReset
            // 
            this.mapReset.Location = new System.Drawing.Point(735, 278);
            this.mapReset.Name = "mapReset";
            this.mapReset.Size = new System.Drawing.Size(75, 23);
            this.mapReset.TabIndex = 5;
            this.mapReset.Text = "resetMap";
            this.mapReset.UseVisualStyleBackColor = true;
            this.mapReset.Click += new System.EventHandler(this.mapReset_Click);
            // 
            // saveMap
            // 
            this.saveMap.Location = new System.Drawing.Point(735, 330);
            this.saveMap.Name = "saveMap";
            this.saveMap.Size = new System.Drawing.Size(75, 23);
            this.saveMap.TabIndex = 6;
            this.saveMap.Text = "Sauvegarder";
            this.saveMap.UseVisualStyleBackColor = true;
            this.saveMap.Click += new System.EventHandler(this.saveMap_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(748, 413);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 212);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // deleteMap
            // 
            this.deleteMap.Location = new System.Drawing.Point(816, 278);
            this.deleteMap.Name = "deleteMap";
            this.deleteMap.Size = new System.Drawing.Size(75, 23);
            this.deleteMap.TabIndex = 8;
            this.deleteMap.Text = "delete";
            this.deleteMap.UseVisualStyleBackColor = true;
            this.deleteMap.Click += new System.EventHandler(this.deleteMap_Click);
            // 
            // loadMaps
            // 
            this.loadMaps.Location = new System.Drawing.Point(816, 330);
            this.loadMaps.Name = "loadMaps";
            this.loadMaps.Size = new System.Drawing.Size(75, 23);
            this.loadMaps.TabIndex = 9;
            this.loadMaps.Text = "load";
            this.loadMaps.UseVisualStyleBackColor = true;
            this.loadMaps.Click += new System.EventHandler(this.loadMaps_Click);
            // 
            // generateJsFile
            // 
            this.generateJsFile.Location = new System.Drawing.Point(767, 370);
            this.generateJsFile.Name = "generateJsFile";
            this.generateJsFile.Size = new System.Drawing.Size(75, 23);
            this.generateJsFile.TabIndex = 10;
            this.generateJsFile.Text = "Generate";
            this.generateJsFile.UseVisualStyleBackColor = true;
            this.generateJsFile.Click += new System.EventHandler(this.generateJsFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 687);
            this.Controls.Add(this.generateJsFile);
            this.Controls.Add(this.loadMaps);
            this.Controls.Add(this.deleteMap);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.saveMap);
            this.Controls.Add(this.mapReset);
            this.Controls.Add(this.empyPlace);
            this.Controls.Add(this.obstacle);
            this.Controls.Add(this.exitPoint);
            this.Controls.Add(this.entryPoint);
            this.Controls.Add(this.generateNewMap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generateNewMap;
        private System.Windows.Forms.Button entryPoint;
        private System.Windows.Forms.Button exitPoint;
        private System.Windows.Forms.Button obstacle;
        private System.Windows.Forms.Button empyPlace;
        private System.Windows.Forms.Button mapReset;
        private System.Windows.Forms.Button saveMap;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button deleteMap;
        private System.Windows.Forms.Button loadMaps;
        private System.Windows.Forms.Button generateJsFile;
    }
}

