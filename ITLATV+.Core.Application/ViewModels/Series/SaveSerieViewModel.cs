using System.ComponentModel.DataAnnotations;
using ITLATV_.Core.Application.ViewModels.Genders;
using ITLATV_.Core.Application.ViewModels.Producers;

public class SaveSerieViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "You must place the Serie Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "You must place the link to the series cover.")]
    public string ImgPath { get; set; }
    [Required(ErrorMessage = "You must place the video link of the series.")]
    public string LinkVideo { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "You must enter the genre of the series.")]
    public int GenderId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "The producer of the series must place.")]
    public int ProducerId { get; set; }

    public List<ProducerViewModel>? Producers { get; set; }
    public List<GenderViewModel>? Genders { get; set; }
}