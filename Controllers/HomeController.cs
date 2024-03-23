using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission11Stokes.Models;
using Mission11Stokes.Models.ViewModels;

namespace Mission11Stokes.Controllers;

public class HomeController : Controller
{
    public IBookRepository _repo;

    public HomeController(IBookRepository temp)
    {
        _repo = temp;
    }

    public IActionResult Index(int pageNum)
    {
        int pageSize = 10;
        var bookFull = new ProjectsListViewModel
        {
            Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
            PaginationInfo = new PaginationInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = _repo.Books.Count()
            }
        };
        return View(bookFull);
    }
    
}