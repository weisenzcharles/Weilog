package org.charles.weilog.service;

import org.charles.weilog.domain.Option;
import org.charles.weilog.domain.PostMeta;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface PostMetaService {
    boolean add(PostMeta postMeta);

    boolean remove(Long id);

    boolean update(PostMeta postMeta);

    PostMeta query(Long id);

    List<PostMeta> query(String title, int pageIndex, int pageSize);

    List<PostMeta> query(int pageIndex, int pageSize);
}