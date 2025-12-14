using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebUI.Dtos.SepetDto
{
    public class ResultSepetDto
    {
        public List<SepetItem> SepetItems { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
