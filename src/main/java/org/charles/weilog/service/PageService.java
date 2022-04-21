package org.charles.weilog.service;

import org.charles.weilog.domain.Page;

import java.util.List;

public interface PageService {
    public boolean add(Page tag);

    public boolean remove(Long id);

    public boolean update(Page tag);

    public Page query(Long id);

    public List<Page> query(String title, int pageIndex, int pageSize);

    public List<Page> query(int pageIndex, int pageSize);
}
