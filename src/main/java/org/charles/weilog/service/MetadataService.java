package org.charles.weilog.service;

import org.charles.weilog.domain.PostMeta;

import java.util.List;

public interface MetadataService {

    boolean add(PostMeta tag);

    boolean remove(Long id);

    boolean update(PostMeta tag);

    PostMeta query(Long id);

    List<PostMeta> query(String title, int pageIndex, int pageSize);

    List<PostMeta> query(int pageIndex, int pageSize);
}
