package org.charles.weilog.service;

import org.charles.weilog.domain.Comment;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface CommentService {
    Comment insert(Comment entity);

    void delete(Long id);

    Comment update(Comment entity);

    Comment query(Long id);

    List<Comment> query(String title, int pageIndex, int pageSize);

    List<Comment> query(int pageIndex, int pageSize);
}