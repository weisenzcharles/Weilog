package org.charles.weilog.service;

import org.charles.weilog.domain.Taxonomy;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface TaxonomyService {
    Taxonomy insert(Taxonomy entity);

    void delete(Long id);

    Taxonomy update(Taxonomy entity);

    Taxonomy query(Long id);

    List<Taxonomy> query(String title, int pageIndex, int pageSize);

    List<Taxonomy> query(int pageIndex, int pageSize);
}