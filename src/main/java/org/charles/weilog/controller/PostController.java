package org.charles.weilog.controller;

import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.data.web.PageableDefault;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/post")
public class PostController {
    @GetMapping(value = "/{id}", params = "id")
    public String post(@PathVariable Long id, Model model) {
        System.out.println(id);
        return "post";
    }

    @GetMapping(value = "/{alias}", params = "alias")
    public String post(@PathVariable String alias, Model model) {
        System.out.println(alias);
        return "post";
    }

    @GetMapping("/list")
    public String list(@PageableDefault(size = 10, sort = {"createdTime"}, direction = Sort.Direction.DESC) Pageable pageable, Model model) {
        return "list";
    }

}
