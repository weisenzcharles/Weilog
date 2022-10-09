package org.charles.weilog.controller.admin;

import org.charles.weilog.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

/**
 * The type User controller.
 */
@Component("UserAdmin")
@Controller
@RequestMapping("admin/user")
public class UserController {

    private final UserService userService;

    @Autowired
    public UserController(UserService userService) {
        this.userService = userService;
    }

    @GetMapping("/list")
    private String list() {
        return "admin/user/list";
    }

    @GetMapping("/edit")
    private String edit() {
        return "admin/user/edit";
    }

    @PostMapping("/save")
    private String save() {
        return "redirect:/list";
    }
}