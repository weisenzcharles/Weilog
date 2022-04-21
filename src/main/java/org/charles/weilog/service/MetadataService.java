package org.charles.weilog.service;

import org.charles.weilog.domain.Metadata;

import java.util.List;

public interface MetadataService {
    public boolean add(Metadata tag);

    public boolean remove(Long id);

    public boolean update(Metadata tag);

    public Metadata query(Long id);

    public List<Metadata> query(String title, int pageIndex, int pageSize);

    public List<Metadata> query(int pageIndex, int pageSize);
}
