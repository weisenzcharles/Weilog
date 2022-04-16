package org.charles.weilog.controller;

import org.springframework.stereotype.Controller;

@Controller
public class PostController {

    public String index() {
        return "post/index";
    }

    public String list(){
        return "post/list";
    }
}
