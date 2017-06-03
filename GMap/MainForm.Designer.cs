namespace GMap
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_zoomin = new System.Windows.Forms.ToolStripButton();
            this.tool_zoomout = new System.Windows.Forms.ToolStripButton();
            this.tool_pan = new System.Windows.Forms.ToolStripButton();
            this.btnOpenMap = new System.Windows.Forms.Button();
            this.btnAddData = new System.Windows.Forms.Button();
            this.btnRender = new System.Windows.Forms.Button();
            this.btnTextElement = new System.Windows.Forms.Button();
            this.btnSpatialQuery = new System.Windows.Forms.Button();
            this.btnAttributeQuery = new System.Windows.Forms.Button();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.listFields = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(677, 326);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_zoomin,
            this.tool_zoomout,
            this.tool_pan});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(975, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_zoomin
            // 
            this.tool_zoomin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_zoomin.Image = ((System.Drawing.Image)(resources.GetObject("tool_zoomin.Image")));
            this.tool_zoomin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_zoomin.Name = "tool_zoomin";
            this.tool_zoomin.Size = new System.Drawing.Size(23, 22);
            this.tool_zoomin.Text = "toolStripButton1";
            this.tool_zoomin.Click += new System.EventHandler(this.tool_zoomin_Click);
            // 
            // tool_zoomout
            // 
            this.tool_zoomout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_zoomout.Image = ((System.Drawing.Image)(resources.GetObject("tool_zoomout.Image")));
            this.tool_zoomout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_zoomout.Name = "tool_zoomout";
            this.tool_zoomout.Size = new System.Drawing.Size(23, 22);
            this.tool_zoomout.Text = "toolStripButton2";
            this.tool_zoomout.Click += new System.EventHandler(this.tool_zoomout_Click);
            // 
            // tool_pan
            // 
            this.tool_pan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_pan.Image = ((System.Drawing.Image)(resources.GetObject("tool_pan.Image")));
            this.tool_pan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_pan.Name = "tool_pan";
            this.tool_pan.Size = new System.Drawing.Size(23, 22);
            this.tool_pan.Text = "toolStripButton3";
            this.tool_pan.Click += new System.EventHandler(this.tool_pan_Click);
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.Location = new System.Drawing.Point(6, 26);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(75, 23);
            this.btnOpenMap.TabIndex = 6;
            this.btnOpenMap.Text = "打开地图";
            this.btnOpenMap.UseVisualStyleBackColor = true;
            this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click);
            // 
            // btnAddData
            // 
            this.btnAddData.Location = new System.Drawing.Point(99, 26);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(75, 23);
            this.btnAddData.TabIndex = 7;
            this.btnAddData.Text = "加载数据";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(192, 26);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(75, 23);
            this.btnRender.TabIndex = 8;
            this.btnRender.Text = "地图渲染";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // btnTextElement
            // 
            this.btnTextElement.Location = new System.Drawing.Point(285, 26);
            this.btnTextElement.Name = "btnTextElement";
            this.btnTextElement.Size = new System.Drawing.Size(75, 23);
            this.btnTextElement.TabIndex = 9;
            this.btnTextElement.Text = "文本标注";
            this.btnTextElement.UseVisualStyleBackColor = true;
            this.btnTextElement.Click += new System.EventHandler(this.btnTextElement_Click);
            // 
            // btnSpatialQuery
            // 
            this.btnSpatialQuery.Location = new System.Drawing.Point(378, 26);
            this.btnSpatialQuery.Name = "btnSpatialQuery";
            this.btnSpatialQuery.Size = new System.Drawing.Size(75, 23);
            this.btnSpatialQuery.TabIndex = 10;
            this.btnSpatialQuery.Text = "空间查询";
            this.btnSpatialQuery.UseVisualStyleBackColor = true;
            this.btnSpatialQuery.Click += new System.EventHandler(this.btnSpatialQuery_Click);
            // 
            // btnAttributeQuery
            // 
            this.btnAttributeQuery.Location = new System.Drawing.Point(869, 90);
            this.btnAttributeQuery.Name = "btnAttributeQuery";
            this.btnAttributeQuery.Size = new System.Drawing.Size(75, 23);
            this.btnAttributeQuery.TabIndex = 11;
            this.btnAttributeQuery.Text = "属性查询";
            this.btnAttributeQuery.UseVisualStyleBackColor = true;
            this.btnAttributeQuery.Click += new System.EventHandler(this.btnAttributeQuery_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(677, 58);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(154, 28);
            this.axToolbarControl1.TabIndex = 4;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(190, 53);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(648, 438);
            this.axMapControl1.TabIndex = 3;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(3, 53);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(183, 438);
            this.axTOCControl1.TabIndex = 1;
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(869, 53);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(75, 21);
            this.txtFieldName.TabIndex = 12;
            // 
            // listFields
            // 
            this.listFields.FormattingEnabled = true;
            this.listFields.HorizontalScrollbar = true;
            this.listFields.ItemHeight = 12;
            this.listFields.Location = new System.Drawing.Point(843, 125);
            this.listFields.Name = "listFields";
            this.listFields.Size = new System.Drawing.Size(127, 148);
            this.listFields.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 494);
            this.Controls.Add(this.listFields);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.btnAttributeQuery);
            this.Controls.Add(this.btnSpatialQuery);
            this.Controls.Add(this.btnTextElement);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.btnAddData);
            this.Controls.Add(this.btnOpenMap);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMap";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_zoomin;
        private System.Windows.Forms.ToolStripButton tool_zoomout;
        private System.Windows.Forms.ToolStripButton tool_pan;
        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Button btnTextElement;
        private System.Windows.Forms.Button btnSpatialQuery;
        private System.Windows.Forms.Button btnAttributeQuery;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.ListBox listFields;
    }
}

