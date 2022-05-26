package org.charles.weilog.service;

import org.charles.weilog.domain.Category;

import java.util.List;

public interface CategoryService {
    boolean add(Category tag);

    boolean remove(Long id);

    boolean update(Category tag);

    Category query(Long id);

    List<Category> query(String title, int pageIndex, int pageSize);

    List<Category> query(int pageIndex, int pageSize);
}
