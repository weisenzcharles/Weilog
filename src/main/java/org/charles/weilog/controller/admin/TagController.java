package org.charles.weilog.controller.admin;

import org.springframework.stereotype.Component;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

/**
 * The type Tag controller.
 */
@Component("TagAdmin")
@Controller
@RequestMapping("admin/tag")
public class TagController {
    @GetMapping("/list")
    private String list() {
        return "admin/tag/list";
    }

    @GetMapping("/edit")
    private String edit() {
        return "admin/tag/edit";
    }

    @PostMapping("/remove")
    private String remove() {
        return "redirect:/list";
    }
}