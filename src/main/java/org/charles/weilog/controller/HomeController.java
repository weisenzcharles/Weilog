package org.charles.weilog.controller;

import org.charles.weilog.domain.Tag;
import org.charles.weilog.service.PostService;
import org.charles.weilog.service.TagService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.data.web.PageableDefault;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.List;

@Controller
public class HomeController {

    @Autowired
    private PostService postService;
    @Autowired
    private TagService tagService;

    @GetMapping("/")
    public String Index(@PageableDefault(size = 10, sort = {"id"}, direction = Sort.Direction.DESC) Pageable pageable, Model model) {
        model.addAttribute("page", postService.listPost(pageable));
//            model.addAttribute("recommend_posts", postService.listType(10));
//            model.addAttribute("types", typeService.listTypeTop(6));
//            model.addAttribute("tags", tagService.listTag(10));
//        List<Type> types = typeService.listTypeTop(7);
        List<Tag> tags = tagService.query(1, 10);
        //User user = (User)session.getAttribute("user");
//        PageInfo<Post> postPageInfo = postService.listPostByPostWithTypeWithUser(pageNum, 5,null);

        //List<Post> postList = postPageInfo.getList();
        //
        //postPageInfo.setList(postList);

//        model.addAttribute("types",types);
        model.addAttribute("tags", tags);
//        model.addAttribute("postPageInfo",postPageInfo);
//        System.out.println(postPageInfo);
        return "index";
    }

}
