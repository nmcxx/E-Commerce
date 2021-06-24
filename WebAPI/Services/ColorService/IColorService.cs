using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Services.ColorService
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetAllColor();
        Task<Color> GetColorByName(string name);
        Task<Color> GetColorById(int id);
        Task<Color> GetColor(Color color);
        Task<bool> DeleteColorById(int id);
        Task<bool> DeleteColorByName(string name);
        Task<bool> DeleteColor(Color color);
        Task<ColorViewModel> AddColor(Color color);
        Task<Color> EditColorById(int id, Color color);
        Task<Color> EditColorByName(string name, Color color);
        bool ColorExistsById(int id);
        bool ColorExistsByName(string name);
    }
}
