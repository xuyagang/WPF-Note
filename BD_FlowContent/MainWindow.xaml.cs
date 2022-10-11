using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BD_FlowContent
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        const string gc_pathAppDataXAML = @"C:\Users\RB\Documents\XAML\";
        const string gc_pathAppDataPNG = @"C:\Users\RB\Documents\PNG\";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (Image img in rtb.FindChildren<Image>())
            {
                img.Loaded += delegate
                {
                    img.PreviewMouseDown += new MouseButtonEventHandler(Image_PreviewMouseDown);
                };
            }
        }

        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rtb.IsReadOnly == false)
            {
                Image img = (Image)e.OriginalSource;

                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(img);
                if (adornerLayer != null)
                {
                    adornerLayer.Add(new ResizingAdorner(img));
                }
            }
        }

        private void SaveContent(object sender, RoutedEventArgs e)
        {
            SaveXamlPackage(gc_pathAppDataXAML + "RTB-Test" + ".xaml");
        }

        private void SaveXamlPackage(string iv_fileName)
        {
            try
            {
                //Separately saving the images
                ExtractImages();

                //Save RTB content with placeholders for the images
                TextRange range1;
                FileStream fStream1;
                range1 = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                fStream1 = new FileStream(iv_fileName, FileMode.Create);
                range1.Save(fStream1, DataFormats.XamlPackage);
                fStream1.Close();

                //Load RichTextBox
                LoadXamlPackage(iv_fileName);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        private void ExtractImages() //Separately saving the images
        {
            Image Image;
            int lv_cnt = 0;

            foreach (Block block in rtb.Document.Blocks)
            {
                if (block is Paragraph)
                {
                    Paragraph paragraph = (Paragraph)block;
                    foreach (Inline inline in paragraph.Inlines)
                    {
                        if (inline is InlineUIContainer)
                        {
                            InlineUIContainer uiContainer = (InlineUIContainer)inline;
                            if (uiContainer.Child is System.Windows.Controls.Image)
                            {
                                lv_cnt++;
                                Image = (Image)uiContainer.Child;
                                SaveToPng(Image, gc_pathAppDataPNG + "RTB-Test".ToString() + "-" + lv_cnt + ".png");

                                Image.Source = new BitmapImage(
                                new Uri("pack://application:,,,/RichTextBox;component/RTB_Platzhalter.png"));
                            }
                        }
                    }
                }
                else if (block is BlockUIContainer)
                {
                    BlockUIContainer container = (BlockUIContainer)block;
                    if (container.Child is Image)
                    {
                        lv_cnt++;
                        Image = (Image)container.Child;
                        SaveToPng(Image, gc_pathAppDataPNG + "RTB-Test".ToString() + "-" + lv_cnt + ".png");

                        Image.Source = new BitmapImage(
                        new Uri("pack://application:,,,/RichTextBox;component/RTB_Platzhalter.png"));
                    }
                }
            }

            void SaveToPng(FrameworkElement visual, string fileName)
            {
                var encoder = new PngBitmapEncoder();
                SaveUsingEncoder(visual, fileName, encoder);
            }

            void SaveUsingEncoder(FrameworkElement visual, string fileName, BitmapEncoder encoder)
            {
                RenderTargetBitmap bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                Size visualSize = new Size(visual.ActualWidth, visual.ActualHeight);
                visual.Measure(visualSize);
                visual.Arrange(new Rect(visualSize));
                bitmap.Render(visual);
                BitmapFrame frame = BitmapFrame.Create(bitmap);
                encoder.Frames.Add(frame);

                using (FileStream stream = File.Create(fileName))
                {
                    encoder.Save(stream);
                }
            }
        }

        private void LoadContent()  //While creating instance of windowRTB
        {
            LoadXamlPackage(gc_pathAppDataXAML + "RTB-Test".ToString() + ".xaml");
        }

        private void LoadXamlPackage(string iv_fileName)
        {
            try
            {
                TextRange range;
                FileStream fStream;
                if (File.Exists(iv_fileName))
                {
                    range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                    fStream = new FileStream(iv_fileName, FileMode.OpenOrCreate);
                    range.Load(fStream, DataFormats.XamlPackage);
                    fStream.Close();
                }

                LoadImages();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        private void LoadImages() //Reloading of separately saved images
        {
            Image Image;
            int lv_cnt = 0;

            foreach (Block block in rtb.Document.Blocks)
            {
                if (block is Paragraph)
                {
                    Paragraph paragraph = (Paragraph)block;
                    foreach (Inline inline in paragraph.Inlines)
                    {
                        if (inline is InlineUIContainer)
                        {
                            InlineUIContainer uiContainer = (InlineUIContainer)inline;
                            if (uiContainer.Child is System.Windows.Controls.Image)
                            {
                                lv_cnt++;
                                Image = (System.Windows.Controls.Image)uiContainer.Child;
                                Image.Source = null;
                                using (FileStream fs = new FileStream(gc_pathAppDataPNG + "RTB-Test".ToString() + "-" + lv_cnt + ".png", FileMode.Open))
                                {
                                    BitmapImage imageSource = new BitmapImage();
                                    imageSource.BeginInit();
                                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                                    imageSource.StreamSource = fs;
                                    imageSource.EndInit();
                                    Image.Source = imageSource;
                                }
                            }
                        }
                    }
                }
                else if (block is BlockUIContainer)
                {
                    BlockUIContainer container = (BlockUIContainer)block;
                    if (container.Child is System.Windows.Controls.Image)
                    {
                        lv_cnt++;
                        Image = (System.Windows.Controls.Image)container.Child;
                        using (FileStream fs = new FileStream(gc_pathAppDataPNG + "RTB-Test".ToString() + "-" + lv_cnt + ".png", FileMode.Open))
                        {
                            BitmapImage imageSource = new BitmapImage();
                            imageSource.BeginInit();
                            imageSource.CacheOption = BitmapCacheOption.OnLoad;
                            imageSource.StreamSource = fs;
                            imageSource.EndInit();
                            Image.Source = imageSource;
                        }
                    }
                }
            }
        }


        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            LoadContent();
        }
    }

    public class ResizingAdorner : Adorner
    {
        // Resizing adorner uses Thumbs for visual elements.   
        // The Thumbs have built-in mouse input handling. 
        Thumb topLeft, topRight, bottomLeft, bottomRight;

        // To store and manage the adorner's visual children. 
        VisualCollection visualChildren;

        // Initialize the ResizingAdorner. 
        public ResizingAdorner(UIElement adornedElement) : base(adornedElement)
        {
            visualChildren = new VisualCollection(this);

            // Call a helper method to initialize the Thumbs 
            // with a customized cursors. 
            BuildAdornerCorner(ref topLeft, Cursors.SizeNWSE);
            BuildAdornerCorner(ref topRight, Cursors.SizeNESW);
            BuildAdornerCorner(ref bottomLeft, Cursors.SizeNESW);
            BuildAdornerCorner(ref bottomRight, Cursors.SizeNWSE);

            // Add handlers for resizing. 
            bottomLeft.DragDelta += new DragDeltaEventHandler(HandleBottomLeft);
            bottomRight.DragDelta += new DragDeltaEventHandler(HandleBottomRight);
            topLeft.DragDelta += new DragDeltaEventHandler(HandleTopLeft);
            topRight.DragDelta += new DragDeltaEventHandler(HandleTopRight);
        }

        // Handler for resizing from the bottom-right. 
        void HandleBottomRight(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;
            FrameworkElement parentElement = adornedElement.Parent as FrameworkElement;

            // Ensure that the Width and Height are properly initialized after the resize. 
            EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger  
            // than the width or height of an adorner, respectively. 
            double lv_oldWidth = adornedElement.Width;
            adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
            adornedElement.Height = adornedElement.Height * adornedElement.Width / lv_oldWidth;
        }

        // Handler for resizing from the bottom-left. 
        void HandleBottomLeft(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement adornedElement = AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;

            // Ensure that the Width and Height are properly initialized after the resize. 
            EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger  
            // than the width or height of an adorner, respectively. 
            double lv_oldWidth = adornedElement.Width;
            adornedElement.Width = Math.Max(adornedElement.Width - args.HorizontalChange, hitThumb.DesiredSize.Width);
            adornedElement.Height = adornedElement.Height * adornedElement.Width / lv_oldWidth;
        }

        // Handler for resizing from the top-right. 
        void HandleTopRight(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;
            FrameworkElement parentElement = adornedElement.Parent as FrameworkElement;

            // Ensure that the Width and Height are properly initialized after the resize. 
            EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger  
            // than the width or height of an adorner, respectively. 
            double lv_oldWidth = adornedElement.Width;
            adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
            adornedElement.Height = adornedElement.Height * adornedElement.Width / lv_oldWidth;
        }

        // Handler for resizing from the top-left. 
        void HandleTopLeft(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement adornedElement = AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;

            // Ensure that the Width and Height are properly initialized after the resize. 
            EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger  
            // than the width or height of an adorner, respectively. 
            double lv_oldWidth = adornedElement.Width;
            adornedElement.Width = Math.Max(adornedElement.Width - args.HorizontalChange, hitThumb.DesiredSize.Width);
            adornedElement.Height = adornedElement.Height * adornedElement.Width / lv_oldWidth;
        }

        // Arrange the Adorners. 
        protected override Size ArrangeOverride(Size finalSize)
        {
            // desiredWidth and desiredHeight are the width and height of the element that's being adorned.   
            // These will be used to place the ResizingAdorner at the corners of the adorned element.   
            double desiredWidth = AdornedElement.DesiredSize.Width;
            double desiredHeight = AdornedElement.DesiredSize.Height;
            // adornerWidth & adornerHeight are used for placement as well. 
            double adornerWidth = this.DesiredSize.Width;
            double adornerHeight = this.DesiredSize.Height;

            topLeft.Arrange(new Rect(-adornerWidth / 2, -adornerHeight / 2, adornerWidth, adornerHeight));
            topRight.Arrange(new Rect(desiredWidth - adornerWidth / 2, -adornerHeight / 2, adornerWidth, adornerHeight));
            bottomLeft.Arrange(new Rect(-adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight));
            bottomRight.Arrange(new Rect(desiredWidth - adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight));

            // Return the final size. 
            return finalSize;
        }

        // Helper method to instantiate the corner Thumbs, set the Cursor property,  
        // set some appearance properties, and add the elements to the visual tree. 
        void BuildAdornerCorner(ref Thumb cornerThumb, Cursor customizedCursor)
        {
            if (cornerThumb != null) return;

            cornerThumb = new Thumb();

            // Set some arbitrary visual characteristics. 
            cornerThumb.Cursor = customizedCursor;
            cornerThumb.Height = cornerThumb.Width = 10;
            cornerThumb.Opacity = 0.40;
            cornerThumb.Background = new SolidColorBrush(Colors.MediumBlue);

            visualChildren.Add(cornerThumb);
        }

        // This method ensures that the Widths and Heights are initialized.  Sizing to content produces 
        // Width and Height values of Double.NaN.  Because this Adorner explicitly resizes, the Width and Height 
        // need to be set first.  It also sets the maximum size of the adorned element. 
        void EnforceSize(FrameworkElement adornedElement)
        {
            if (adornedElement.Width.Equals(Double.NaN))
                adornedElement.Width = adornedElement.DesiredSize.Width;
            if (adornedElement.Height.Equals(Double.NaN))
                adornedElement.Height = adornedElement.DesiredSize.Height;

            FrameworkElement parent = adornedElement.Parent as FrameworkElement;
            if (parent != null)
            {
                adornedElement.MaxHeight = parent.ActualHeight;
                adornedElement.MaxWidth = parent.ActualWidth;
            }
        }
        // Override the VisualChildrenCount and GetVisualChild properties to interface with  
        // the adorner's visual collection. 
        protected override int VisualChildrenCount { get { return visualChildren.Count; } }
        protected override Visual GetVisualChild(int index) { return visualChildren[index]; }
    }

    /// <summary>
    /// Helper methods for UI-related tasks.
    /// </summary>
    public static class TreeHelper
    {
        #region find parent
        public static T TryFindParent<T>(this DependencyObject child)
            where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = GetParentObject(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                //use recursion to proceed with next level
                return TryFindParent<T>(parentObject);
            }
        }

        public static DependencyObject GetParentObject(this DependencyObject child)
        {
            if (child == null) return null;

            //handle content elements separately
            ContentElement contentElement = child as ContentElement;
            if (contentElement != null)
            {
                DependencyObject parent = ContentOperations.GetParent(contentElement);
                if (parent != null) return parent;

                FrameworkContentElement fce = contentElement as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }

            //also try searching for parent in framework elements (such as DockPanel, etc)
            FrameworkElement frameworkElement = child as FrameworkElement;
            if (frameworkElement != null)
            {
                DependencyObject parent = frameworkElement.Parent;
                if (parent != null) return parent;
            }

            //if it's not a ContentElement/FrameworkElement, rely on VisualTreeHelper
            return VisualTreeHelper.GetParent(child);
        }

        #endregion

        #region find children

        public static IEnumerable<T> FindChildren<T>(this DependencyObject source) where T : DependencyObject
        {
            if (source != null)
            {
                var childs = GetChildObjects(source);
                foreach (DependencyObject child in childs)
                {
                    //analyze if children match the requested type
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    //recurse tree
                    foreach (T descendant in FindChildren<T>(child))
                    {
                        yield return descendant;
                    }
                }
            }
        }

        public static IEnumerable<DependencyObject> GetChildObjects(this DependencyObject parent)
        {
            if (parent == null) yield break;

            if (parent is ContentElement || parent is FrameworkElement)
            {
                //use the logical tree for content / framework elements
                foreach (object obj in LogicalTreeHelper.GetChildren(parent))
                {
                    var depObj = obj as DependencyObject;
                    if (depObj != null) yield return (DependencyObject)obj;
                }
            }
            else
            {
                //use the visual tree per default
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    yield return VisualTreeHelper.GetChild(parent, i);
                }
            }
        }

        #endregion

        #region find from point

        public static T TryFindFromPoint<T>(UIElement reference, Point point)
            where T : DependencyObject
        {
            DependencyObject element = reference.InputHitTest(point) as DependencyObject;

            if (element == null) return null;
            else if (element is T) return (T)element;
            else return TryFindParent<T>(element);
        }

        #endregion
    }
}
