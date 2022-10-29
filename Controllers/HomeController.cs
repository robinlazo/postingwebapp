using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SocialMedia.Controllers;

[Authorize]
public class HomeController : Controller
{
    private PostingContextUnitOfWork data {get; }
    public HomeController(PostingContext ctx) => data = new(ctx);

  
    public IActionResult Filter(IndexDTO values) {
        IndexSession session = new IndexSession(HttpContext.Session);
        session.CurrentRoute.CategoryFilter = values.Category;
        session.CurrentRoute.SortDirection = values.SortDirection;
    
        return RedirectToAction("Index", session.CurrentRoute);
    }

    public IActionResult Index(IndexDTO filterData) {
        IndexSession session = new IndexSession(HttpContext.Session, filterData);

        PostQueryOptions queryOptions = new PostQueryOptions
        {
            Include = "Category, User, Comments",
            OrderByDirection = session.CurrentRoute.SortDirection,
            OrderBy = p => p.Time
        };

        queryOptions.SortFilter(session);

        HomeViewModel vm = new HomeViewModel
        {
            Posts = data.Posts.List(queryOptions),
            Routes = session.CurrentRoute,
            Categories = data.Categories.List(new QueryOptions<Category> {
                OrderBy = c => c.Name
            })
        };

        return View(vm);
    }

    [HttpGet]
    public IActionResult Publish() {
        PublishDTO dataDTO = new PublishDTO
        {
            Categories = data.Categories.List(new QueryOptions<Category>())
        };
        return View(dataDTO);
    }
    

    [HttpPost]
    public IActionResult Publish(PublishDTO dataDTO) {
        var validate = new Validate();
        validate.CheckCategory(data.Categories, dataDTO.CategoryID);

        if(!validate.IsValid) {
            ModelState.AddModelError(nameof(PublishDTO.CategoryID), validate.ErrorMessage);
        }

        if(ModelState.IsValid) {

            Post newPost = new Post
            {
                Time = DateTime.Now,
                Description = dataDTO.Description,
                Title = dataDTO.Title, 
                UserID = GetUserID(),
                CategoryID = dataDTO.CategoryID
            };

            data.Posts.Insert(newPost);
            data.Save();
            return RedirectToAction("Index", new IndexSession(HttpContext.Session).CurrentRoute);
        }

        dataDTO.Categories = data.Categories.List(new QueryOptions<Category>());
        return View(dataDTO);
    }

    public IActionResult PostInfo(int id) {
        var validate = new Validate();
        validate.CheckPost(data.Posts, id);

        if(!validate.IsValid) {
            return RedirectToAction("Index");
        }

        PostViewModel vm = new PostViewModel
        {
            Post = data.Posts.Get(new QueryOptions<Post>
            {
                Where = p => p.PostID == id,
                Include = "Comments.Replies, User, Comments.Replies.User"
            }),
            CommentDTO = new CommentDTO {
                PostID = id
            }
        };
    
        return View(vm);
    }
 
    [HttpPost]
    public IActionResult Reply(ReplyDTO replyDTO) {

        if(ModelState.IsValid) {
            Reply reply = new Reply
            {
                CommentID = replyDTO.CommentID,
                Content = replyDTO.Content,
                Time = DateTime.Now,
                UserID = GetUserID()
            };

            data.Replies.Insert(reply);
            data.Save();
        }

        return RedirectToAction("Index", new IndexSession(HttpContext.Session).CurrentRoute);
    }

    [HttpPost]
    public IActionResult Comment(CommentDTO comment) {
        if(ModelState.IsValid) {
            Comment newComment = new Comment
            {   
                PostID = comment.PostID,
                Content = comment.Content,
                Time = DateTime.Now,
                UserID = GetUserID()
            };
            
            data.Comments.Insert(newComment);
            data.Save();
        }

        return RedirectToAction("Index", new IndexSession(HttpContext.Session).CurrentRoute);
    }

    private int GetUserID() => Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
}
