package org.charles.weilog.service;

import org.charles.weilog.domain.Metadata;

import java.util.List;

public interface MetadataService {

    boolean add(Metadata tag);

    boolean remove(Long id);

    boolean update(Metadata tag);

    Metadata query(Long id);

    List<Metadata> query(String title, int pageIndex, int pageSize);

    List<Metadata> query(int pageIndex, int pageSize);
}
