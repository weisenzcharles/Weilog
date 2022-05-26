package org.charles.weilog.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class PostController {
    @GetMapping("/post/index")
    public String index() {
        return "post/index";
    }

    @GetMapping("/post/list")
    public String list() {
        return "post/list";
    }
}
