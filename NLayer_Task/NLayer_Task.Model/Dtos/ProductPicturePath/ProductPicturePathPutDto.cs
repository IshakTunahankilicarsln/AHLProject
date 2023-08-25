namespace NLayer_Task.Model.Dtos.ProductPicturePath
{
    public class ProductPicturePathPutDto
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        public string? PicturePath { get; set; }
    }
}
