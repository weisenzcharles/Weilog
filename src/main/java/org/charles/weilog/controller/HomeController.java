package org.charles.weilog.controller;

import org.charles.weilog.domain.Tag;
import org.charles.weilog.service.TagService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

import javax.servlet.http.HttpSession;
import java.util.List;

@Controller
public class HomeController {

    @Autowired
    private TagService tagService;

    @GetMapping("/")
    public String toIndexPage(@RequestParam(name = "pageSize", defaultValue = "1", required = false) Integer pageSize, Model model, HttpSession session) {

//        List<Type> types = typeService.listTypeTop(7);
        List<Tag> tags = tagService.query(1, 10);
        //User user = (User)session.getAttribute("user");
//        PageInfo<Blog> blogPageInfo = blogService.listBlogByBlogWithTypeWithUser(pageSize, 5,null);

        //List<Blog> blogList = blogPageInfo.getList();
        //
        //blogPageInfo.setList(blogList);

//        model.addAttribute("types",types);
        model.addAttribute("tags", tags);
//        model.addAttribute("blogPageInfo",blogPageInfo);
//        System.out.println(blogPageInfo);
        return "index";
    }

}
