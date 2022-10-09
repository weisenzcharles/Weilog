package org.charles.weilog.controller.admin;

import org.charles.weilog.service.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

/**
 * The type Post controller.
 */
@Component("PostAdmin")
@Controller
@RequestMapping("admin/post")
public class PostController {

    private UserService userService;
    private PostService postService;
    private PostMetaService postMetaService;
    private AttachmentService attachmentService;
    private TaxonomyService taxonomyService;
    private TagService tagService;


    /**
     * Instantiates a new Post controller.
     *
     * @param userService       the user service
     * @param postService       the post service
     * @param postMetaService   the post meta service
     * @param attachmentService the attachment service
     * @param taxonomyService   the taxonomy service
     * @param tagService        the tag service
     */
    @Autowired
    public PostController(UserService userService, PostService postService, PostMetaService postMetaService, AttachmentService attachmentService, TaxonomyService taxonomyService, TagService tagService) {
        this.userService = userService;
        this.postService = postService;
        this.postMetaService = postMetaService;
        this.attachmentService = attachmentService;
        this.taxonomyService = taxonomyService;
        this.tagService = tagService;
    }

    @GetMapping("/list")
    private String list() {
        return "admin/post/list";
    }

    @GetMapping("/edit")
    private String edit() {
        return "admin/post/edit";
    }
}