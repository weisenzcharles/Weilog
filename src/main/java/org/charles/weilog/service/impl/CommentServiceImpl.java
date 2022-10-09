package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Comment;
import org.charles.weilog.repository.CommentRepository;
import org.charles.weilog.service.CommentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * The type Comment service.
 */
@Service
public class CommentServiceImpl implements CommentService {

    private final CommentRepository commentRepository;

    /**
     * Instantiates a new Comment service.
     *
     * @param commentRepository the comment repository
     */
    @Autowired
    public CommentServiceImpl(CommentRepository commentRepository) {
        this.commentRepository = commentRepository;
    }

    @Override
    public boolean add(Comment tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(Comment tag) {
        return false;
    }

    @Override
    public Comment query(Long id) {
        return null;
    }

    @Override
    public List<Comment> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Comment> query(int pageIndex, int pageSize) {
        return null;
    }
}