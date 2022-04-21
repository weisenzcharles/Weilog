package org.charles.weilog.service;

import org.charles.weilog.domain.Category;

import java.util.List;

public interface CategoryService {
    public boolean add(Category tag);

    public boolean remove(Long id);

    public boolean update(Category tag);

    public Category query(Long id);

    public List<Category> query(String title, int pageIndex, int pageSize);

    public List<Category> query(int pageIndex, int pageSize);
}
