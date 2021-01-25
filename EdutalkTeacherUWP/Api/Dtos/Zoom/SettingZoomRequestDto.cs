using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.Zoom
{
    public class SettingZoomRequestDto
    {
        public long Id { set; get; }
        public string ZoomId { set; get; }
        public string ZoomPassword { set; get; }
    }
}
