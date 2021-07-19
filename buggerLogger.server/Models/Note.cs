using System;
using System.Collections.Generic;

namespace buggerLogger.Models
{
  public class Note
  {
    public string Body { get; set; }
    public Bug Bug { get; set; }
    public string CreatorId { get; set; }
    
  }
}