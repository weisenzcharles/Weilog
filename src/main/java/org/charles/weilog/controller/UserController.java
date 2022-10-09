package org.charles.weilog.controller;

import org.charles.weilog.domain.User;
import org.charles.weilog.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import javax.servlet.http.HttpSession;

@Controller
@RequestMapping("/user")
public class UserController {
    @Autowired
    private HttpSession httpSession;
    @Autowired
    private UserService userService;

    @PostMapping("/login")
    public String login(@RequestParam String username,
                        @RequestParam String password,
                        HttpSession session,
                        RedirectAttributes attributes, Model model, Pageable pageable) {
        User user = userService.login(username, password);
        if (user != null) {
            user.setPassword(null);
            httpSession.setAttribute("user", user);
            // model.addAttribute("page", blogService.listBlog(pageable));
            all(model);
            return "index";
        }
        attributes.addFlashAttribute("message", "用户名和密码错误");
        return "login";
    }

    private void all(Model model) {
        // model.addAttribute("messagesize",messageService.AlistMessage().size());
        // model.addAttribute("commentsize",commentService.listComment().size());
        // model.addAttribute("blogVsize",blogService.countBlog());
    }

    @PostMapping("/logout")
    public String logout() {
        httpSession.removeAttribute("user");
        return "redirect:/index";
    }

}