package org.charles.weilog.service;

import org.charles.weilog.domain.Taxonomy;

import java.util.List;

public interface CategoryService {
    boolean add(Taxonomy tag);

    boolean remove(Long id);

    boolean update(Taxonomy tag);

    Taxonomy query(Long id);

    List<Taxonomy> query(String title, int pageIndex, int pageSize);

    List<Taxonomy> query(int pageIndex, int pageSize);
}
