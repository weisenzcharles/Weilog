package org.charles.weilog.service;

import org.charles.weilog.domain.Option;
import org.charles.weilog.domain.PostMeta;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface PostMetaService {
    PostMeta insert(PostMeta entity);

    void delete(Long id);

    PostMeta update(PostMeta entity);

    PostMeta query(Long id);

    List<PostMeta> query(String title, int pageIndex, int pageSize);

    List<PostMeta> query(int pageIndex, int pageSize);
}