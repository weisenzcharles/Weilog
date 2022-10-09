package org.charles.weilog.service;

import java.util.List;

public interface PageService {
    boolean add(Page tag);

    boolean remove(Long id);

    boolean update(Page tag);

    Page query(Long id);

    List<Page> query(String title, int pageIndex, int pageSize);

    List<Page> query(int pageIndex, int pageSize);
}