package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Metadata;
import org.charles.weilog.service.MetadataService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class MetadataServiceImpl implements MetadataService {
    @Override
    public boolean add(Metadata tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(Metadata tag) {
        return false;
    }

    @Override
    public Metadata query(Long id) {
        return null;
    }

    @Override
    public List<Metadata> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Metadata> query(int pageIndex, int pageSize) {
        return null;
    }
}
