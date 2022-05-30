package org.charles.weilog.controller;

import org.charles.weilog.domain.Term;
import org.charles.weilog.service.TermService;
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
    private TermService tagService;

    @GetMapping("/")
    public String toIndexPage(@RequestParam(name = "pageNum",defaultValue = "1",required = false)
                                      Integer pageNum, Model model, HttpSession session){

//        List<Type> types = typeService.listTypeTop(7);
        List<Term> terms = tagService.query(1,10);
        //User user = (User)session.getAttribute("user");
//        PageInfo<Blog> blogPageInfo = blogService.listBlogByBlogWithTypeWithUser(pageNum, 5,null);

        //List<Blog> blogList = blogPageInfo.getList();
        //
        //blogPageInfo.setList(blogList);

//        model.addAttribute("types",types);
        model.addAttribute("tags", terms);
//        model.addAttribute("blogPageInfo",blogPageInfo);
//        System.out.println(blogPageInfo);
        return "index";
    }

}
