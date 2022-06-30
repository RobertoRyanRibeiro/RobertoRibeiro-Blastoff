using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage ="O Campo Nome é Obrigatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O Campo Slug é Obrigatorio")]
        public string Slug { get; set; }

    }
}
