package org.charles.weilog.service;

import org.charles.weilog.domain.Category;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CategoryServiceImpl implements CategoryService {
    @Override
    public boolean add(Category tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(Category tag) {
        return false;
    }

    @Override
    public Category query(Long id) {
        return null;
    }

    @Override
    public List<Category> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Category> query(int pageIndex, int pageSize) {
        return null;
    }
}
