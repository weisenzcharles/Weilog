package org.charles.weilog.service;

import org.charles.weilog.domain.Comment;
import org.charles.weilog.domain.CommentMeta;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface CommentMetaService {
    boolean add(CommentMeta commentMeta);

    boolean remove(Long id);

    boolean update(CommentMeta commentMeta);

    CommentMeta query(Long id);

    List<CommentMeta> query(String title, int pageIndex, int pageSize);

    List<CommentMeta> query(int pageIndex, int pageSize);
}