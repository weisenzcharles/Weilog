package org.charles.weilog.service;

import org.charles.weilog.domain.Comment;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CommentServiceImpl implements CommentService {
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
