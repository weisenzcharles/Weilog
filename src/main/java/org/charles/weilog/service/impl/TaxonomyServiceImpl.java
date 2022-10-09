package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Taxonomy;
import org.charles.weilog.service.TaxonomyService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TaxonomyServiceImpl implements TaxonomyService {
    @Override
    public boolean add(Taxonomy tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(Taxonomy tag) {
        return false;
    }

    @Override
    public Taxonomy query(Long id) {
        return null;
    }

    @Override
    public List<Taxonomy> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Taxonomy> query(int pageIndex, int pageSize) {
        return null;
    }
}