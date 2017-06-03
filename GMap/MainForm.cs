//****************
//****************
//作者：黄铜
//日期:2017.06.02
//注意：代码中的字段名称需根据使用的具体数据做出相应更改
//****************
//*****************

using System;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;


namespace GMap
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //鼠标操作
        string pMouseOperate = null;

        //放大
        private void tool_zoomin_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "ZoomIn";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomIn;
        }

        //缩小
        private void tool_zoomout_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "ZoomOut";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomOut;
        }

        //漫游
        private void tool_pan_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "Pan";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPan;
        }

        //鼠标点击事件
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (pMouseOperate == "ZoomIn")
            {
                axMapControl1.Extent = axMapControl1.TrackRectangle();
            }
            if (pMouseOperate == "ZoomOut")
            {
                IEnvelope penv = axMapControl1.Extent;
                penv.Expand(2, 2, true);
                axMapControl1.Extent = penv;
            }
            if (pMouseOperate == "Pan")
            {
                axMapControl1.Pan();
            }
            if (pMouseOperate == "Identify")
            {
                IPoint point = new ESRI.ArcGIS.Geometry.Point();
                point.PutCoords(e.mapX, e.mapY);
                IFeatureLayer pFeatureLayer = axMapControl1.get_Layer(0) as IFeatureLayer;
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                string shapefieldname = pFeatureClass.ShapeFieldName;
                ESRI.ArcGIS.Geodatabase.ISpatialFilter pSpatialFilter = new ESRI.ArcGIS.Geodatabase.SpatialFilter();
                pSpatialFilter.Geometry = point;
                pSpatialFilter.SpatialRel = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelIntersects;
                pSpatialFilter.set_OutputSpatialReference(shapefieldname, axMapControl1.SpatialReference);
                pSpatialFilter.GeometryField = shapefieldname;
                ESRI.ArcGIS.Geodatabase.IFeatureCursor pFeatureCursor = pFeatureClass.Search(pSpatialFilter, false);
                ESRI.ArcGIS.Geodatabase.IFeature pFeature = pFeatureCursor.NextFeature();
                if (pFeature != null)
                {
                    axMapControl1.FlashShape(pFeature.Shape);
                }
                IFields pField = pFeature.Fields;
                listFields.Items.Clear();
                for (int i = 0; i <= pField.FieldCount - 1; i++)
                {
                    listFields.Items.Add(pField.get_Field(i).Name + "=" + pFeature.get_Value(i));
                }
            }

        }

        //打开地图文档
        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog pOpenFileDialog = new OpenFileDialog();
                pOpenFileDialog.CheckFileExists = true;
                pOpenFileDialog.Title = "打开地图文档";
                pOpenFileDialog.Filter = "ArcMap文档(*.mxd)|*.mxd;|ArcMap模板(*.mxt)|*.mxt|发布地图文件(*.pmf)|*.pmf|所有地图格式(*.mxd;*.mxt;*.pmf)|*.mxd;*.mxt;*.pmf";
                pOpenFileDialog.Multiselect = false;
                pOpenFileDialog.RestoreDirectory = true;
                if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pFileName = pOpenFileDialog.FileName;
                    if (pFileName == "")
                    {
                        return;
                    }

                    //检查地图文档有效性
                    if (axMapControl1.CheckMxFile(pFileName))
                    {
                        //将数据载入pMapDocument并与Map控件关联
                        IMapDocument pMapDocument = new MapDocument();
                        pMapDocument.Open(pFileName, "");

                        //获取Map中激活的地图文档
                        axMapControl1.Map = pMapDocument.ActiveView.FocusMap;
                        axMapControl1.ActiveView.Refresh();
                    }
                    else
                    {
                        MessageBox.Show(pFileName + "是无效的地图文档!", "信息提示");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开地图文档失败" + ex.Message);
            }
        }

        //添加数据
        private void btnAddData_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog pOpenFileDialog = new OpenFileDialog();
                pOpenFileDialog.CheckFileExists = true;
                pOpenFileDialog.Title = "打开Shape文件";
                pOpenFileDialog.Filter = "Shape文件（*.shp）|*.shp";
                pOpenFileDialog.ShowDialog();

                IWorkspaceFactory pWorkspaceFactory;
                IFeatureWorkspace pFeatureWorkspace;
                IFeatureLayer pFeatureLayer;

                string pFullPath = pOpenFileDialog.FileName;
                if (pFullPath == "") return;

                int pIndex = pFullPath.LastIndexOf("\\");

                //文件路径
                string pFilePath = pFullPath.Substring(0, pIndex);

                //文件名
                string pFileName = pFullPath.Substring(pIndex + 1);

                //实例化ShapefileWorkspaceFactory工作空间，打开Shape文件
                pWorkspaceFactory = new ShapefileWorkspaceFactory();
                pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(pFilePath, 0);

                //创建并实例化要素集
                IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(pFileName);
                pFeatureLayer = new FeatureLayer();
                pFeatureLayer.FeatureClass = pFeatureClass;
                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;

                axMapControl1.Map.AddLayer(pFeatureLayer);
                axMapControl1.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("图层加载失败！" + ex.Message);
            }
        }

        //地图渲染
        private void btnRender_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer PGeoFeatureLayer = (IGeoFeatureLayer)axMapControl1.get_Layer(0);
            IUniqueValueRenderer pUniqueValueRenderer = CreateTrackUniqueValueRenderer(PGeoFeatureLayer.FeatureClass, "TYPE");

            PGeoFeatureLayer.Renderer = (IFeatureRenderer)pUniqueValueRenderer;

            axMapControl1.ActiveView.Refresh();
            axTOCControl1.SetActiveView(axTOCControl1.ActiveView);
        }

        //唯一值渲染
        private IUniqueValueRenderer CreateTrackUniqueValueRenderer(IFeatureClass featureClass, string fieldName)
        {
            IRgbColor color = new RgbColor();
            color.Red = 0;
            color.Blue = 0;
            color.Green = 255;

            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbol();
            simpleLineSymbol.Color = (IColor)color;
            simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            simpleLineSymbol.Width = 1.0;

            IUniqueValueRenderer uniqueRenderer = new UniqueValueRenderer();
            uniqueRenderer.FieldCount = 1;
            uniqueRenderer.set_Field(0, fieldName);
            uniqueRenderer.DefaultSymbol = (ISymbol)simpleLineSymbol;
            uniqueRenderer.UseDefaultSymbol = true;

            Random rand = new Random();
            bool bValFound = false;
            IFeatureCursor featureCursor = featureClass.Search(null, true);
            IFeature feature = null;
            string val = string.Empty;
            int fieldID = featureClass.FindField(fieldName);
            if (-1 == fieldID)
                return uniqueRenderer;

            while ((feature = featureCursor.NextFeature()) != null)
            {
                bValFound = false;
                val = Convert.ToString(feature.get_Value(fieldID));
                for (int i = 0; i < uniqueRenderer.ValueCount - 1; i++)
                {
                    if (uniqueRenderer.get_Value(i) == val)
                        bValFound = true;
                }

                if (!bValFound)//need to add the value to the renderer
                {
                    color.Red = rand.Next(255);
                    color.Blue = rand.Next(255);
                    color.Green = rand.Next(255);

                    simpleLineSymbol = new SimpleLineSymbol();
                    simpleLineSymbol.Color = (IColor)color;
                    simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
                    simpleLineSymbol.Width = 1.0;

                    uniqueRenderer.AddValue(val, "name", (ISymbol)simpleLineSymbol);
                }
            }

            ESRI.ArcGIS.ADF.ComReleaser.ReleaseCOMObject(featureCursor);

            return uniqueRenderer;
        }
      
        //文本标注
        private void btnTextElement_Click(object sender, EventArgs e)
        {
            if (axMapControl1.LayerCount > 0)
            {
                IGeoFeatureLayer pGeoFeatureLayer;
                ILineLabelPosition pLineLabelPosition;
                ILabelEngineLayerProperties pLabelEngineLayerProperties;
                IAnnotateLayerProperties pAnnotateLayerProperties;

                pGeoFeatureLayer = (IGeoFeatureLayer)axMapControl1.get_Layer(0);
                pGeoFeatureLayer.AnnotationProperties.Clear();

                pLineLabelPosition = new LineLabelPosition();
                pLineLabelPosition.Above = false;
                pLineLabelPosition.AtEnd = false;
                pLineLabelPosition.Below = false;
                pLineLabelPosition.Horizontal = false;
                pLineLabelPosition.InLine = true;
                pLineLabelPosition.OnTop = true;
                pLineLabelPosition.Parallel = true;
                pLineLabelPosition.ProduceCurvedLabels = true;

                ITextSymbol pTextSymbol = new TextSymbol();
                IColor pColor = new RgbColor();
                pColor.RGB = 100;
                pTextSymbol.Size = 12;
                pTextSymbol.Font.Name = "宋体";
                pTextSymbol.Color = pColor;

                pLabelEngineLayerProperties = new LabelEngineLayerProperties() as ILabelEngineLayerProperties;
                pLabelEngineLayerProperties.Symbol = pTextSymbol;
                pLabelEngineLayerProperties.IsExpressionSimple = true;
                pLabelEngineLayerProperties.Expression = "[DESCRIP]";//需要中括号,这里显示NAME字段属性
                pLabelEngineLayerProperties.BasicOverposterLayerProperties.LineLabelPosition = pLineLabelPosition;

                pAnnotateLayerProperties = (IAnnotateLayerProperties)pLabelEngineLayerProperties;
                pAnnotateLayerProperties.DisplayAnnotation = true;
                pAnnotateLayerProperties.FeatureLayer = pGeoFeatureLayer;

                pAnnotateLayerProperties.LabelWhichFeatures = esriLabelWhichFeatures.esriAllFeatures;
                pAnnotateLayerProperties.WhereClause = "";

                pGeoFeatureLayer.AnnotationProperties.Add(pAnnotateLayerProperties);
                pGeoFeatureLayer.DisplayAnnotation = true;
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                axMapControl1.ActiveView.Refresh();
            }
        }

        //空间查询
        private void btnSpatialQuery_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "Identify";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerIdentify;
        }

        //属性查询
        private void btnAttributeQuery_Click(object sender, EventArgs e)
        {

            IFeatureLayer pFeatureLayer = axMapControl1.get_Layer(0) as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IQueryFilter pQueryFilter = new QueryFilter();
            pQueryFilter.WhereClause = "DESCRIP='" + txtFieldName.Text.ToString() + "'";
            IFeatureCursor pFeatureCursor = pFeatureClass.Search(pQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            axMapControl1.Map.ClearSelection();

            if (pFeature != null)
            {
                axMapControl1.FlashShape(pFeature.Shape);
            }
            axMapControl1.Map.SelectFeature(pFeatureLayer, pFeature);
            axMapControl1.ActiveView.Refresh();
            IFields pField = pFeature.Fields;
            listFields.Items.Clear();
            for (int i = 0; i <= pField.FieldCount - 1; i++)
            {
                listFields.Items.Add(pField.get_Field(i).Name + "=" + pFeature.get_Value(i));
            }
        }


    }
}
