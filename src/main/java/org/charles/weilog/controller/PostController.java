package org.charles.weilog.controller;

import org.charles.weilog.domain.Post;
import org.charles.weilog.service.PostService;
import org.springframework.beans.factory.annotation.Autowired;
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

    private final PostService postService;

    @Autowired
    public PostController(PostService postService) {
        this.postService = postService;
    }

    /**
     * 文章详情
     *
     * @param idOrAlias
     *         文章 Id 或别名
     * @param model
     *         模型
     */
    @GetMapping(value = "/{idOrAlias}")
    public String post(@PathVariable String idOrAlias, Model model) {
        System.out.println(idOrAlias);
        Post post;
        try {
            Long id = Long.valueOf(idOrAlias);
            post = postService.findById(id);
            System.out.println(id);
        } catch (NumberFormatException e) {
            post = postService.findByAlias(idOrAlias);
            System.out.println(idOrAlias);
        }
        System.out.println(post);
        return "post";
    }

    /**
     * 文章列表
     *
     * @param pageable
     *         分页对象
     * @param model
     *         模型
     */
    @GetMapping("/list")
    public String list(@PageableDefault(size = 10, sort = {"updatedTime"}, direction = Sort.Direction.DESC) Pageable pageable, Model model) {
        return "list";
    }

}
