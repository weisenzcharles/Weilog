package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Page;
import org.charles.weilog.service.PageService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PageServiceImpl implements PageService {
    @Override
    public boolean add(Page tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(Page tag) {
        return false;
    }

    @Override
    public Page query(Long id) {
        return null;
    }

    @Override
    public List<Page> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Page> query(int pageIndex, int pageSize) {
        return null;
    }
}
