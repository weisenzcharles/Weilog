package org.charles.weilog.service;

import org.charles.weilog.domain.Comment;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface CommentService {
    boolean add(Comment tag);

    boolean remove(Long id);

    boolean update(Comment tag);

    Comment query(Long id);

    List<Comment> query(String title, int pageIndex, int pageSize);

    List<Comment> query(int pageIndex, int pageSize);
}