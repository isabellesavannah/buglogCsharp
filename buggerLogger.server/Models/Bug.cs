using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace buggerLogger.Models
{
  public class Bug
  {
    public bool Closed { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Title { get; set; }
    public DateTime ClosedDate { get; set; }
    [Required]
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }

  }
}