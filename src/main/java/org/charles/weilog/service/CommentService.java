package org.charles.weilog.service;

import org.charles.weilog.domain.Comment;

import java.util.List;

public interface CommentService {
    public boolean add(Comment tag);

    public boolean remove(Long id);

    public boolean update(Comment tag);

    public Comment query(Long id);

    public List<Comment> query(String title, int pageIndex, int pageSize);

    public List<Comment> query(int pageIndex, int pageSize);
}
