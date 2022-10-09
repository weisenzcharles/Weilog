package org.charles.weilog.service.impl;

import org.charles.weilog.domain.PostMeta;
import org.charles.weilog.service.MetadataService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class MetadataServiceImpl implements MetadataService {
    @Override
    public boolean add(PostMeta tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(PostMeta tag) {
        return false;
    }

    @Override
    public PostMeta query(Long id) {
        return null;
    }

    @Override
    public List<PostMeta> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<PostMeta> query(int pageIndex, int pageSize) {
        return null;
    }
}
