package org.charles.weilog.controller.admin;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

/**
 * The type Attachment controller.
 */
@Controller
@RequestMapping("admin/attachment")
public class AttachmentController {

    @GetMapping("/list")
    private String list() {
        return "admin/post/list";
    }

    @GetMapping("/edit")
    private String edit() {
        return "admin/post/edit";
    }
}