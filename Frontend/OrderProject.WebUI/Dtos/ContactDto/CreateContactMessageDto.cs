using System.ComponentModel.DataAnnotations;

namespace OrderProject.WebUI.Dtos.ContactDto
{
    public class CreateContactMessageDto
    {
      
            [Required(ErrorMessage = "Adınızı Soyadınızı giriniz.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Mail adresinizi giriniz.")]
            [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
            public string Mail { get; set; }

            [Required(ErrorMessage = "Lütfen bir kategori seçin.")]
            public int MessageCategoryID { get; set; }

            [Required(ErrorMessage = "Konu başlığını giriniz.")]
            public string Subject { get; set; }

            [Required(ErrorMessage = "Mesajınızı yazınız.")]
            [MinLength(10, ErrorMessage = "Mesajınız en az 10 karakter olmalıdır.")]
            public string Message { get; set; }
        
    }
}
