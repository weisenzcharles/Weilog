package org.charles.weilog.service;

import org.charles.weilog.domain.Comment;
import org.charles.weilog.domain.CommentMeta;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface CommentMetaService {
    CommentMeta insert(CommentMeta entity);

    void delete(Long id);

    CommentMeta update(CommentMeta entity);

    CommentMeta query(Long id);

    List<CommentMeta> query(String title, int pageIndex, int pageSize);

    List<CommentMeta> query(int pageIndex, int pageSize);
}